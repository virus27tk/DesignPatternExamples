import os
import re
import subprocess
import sys
from typing import List


def run(cmd: str) -> str:
    result = subprocess.run(cmd, shell=True, capture_output=True, text=True)
    if result.returncode != 0:
        print(f"Command failed: {cmd}")
        print(result.stdout)
        print(result.stderr)
        sys.exit(result.returncode)
    return result.stdout.strip()


def get_commit_messages() -> List[str]:
    """
    Get commit messages in this PR by diffing base branch and HEAD.
    """
    base_ref = os.environ.get("GITHUB_BASE_REF")
    if not base_ref:
        print("GITHUB_BASE_REF is not set. Are you running on a pull_request event?")
        sys.exit(1)

    # Find common ancestor between HEAD and base branch
    base_sha = run(f"git merge-base HEAD origin/{base_ref}")
    logs = run(f"git log --format=%B {base_sha}...HEAD")
    messages = [m.strip() for m in logs.split("\n\n") if m.strip()]
    return messages


def extract_ratings(messages: List[str]) -> List[int]:
    """
    Look for patterns like 'CodeRating: 4/5' (case-insensitive) in commit messages.
    Returns a list of all ratings found.
    """
    pattern = re.compile(r"CodeRating:\s*([1-5])\s*/\s*5", re.IGNORECASE)
    ratings = []

    for msg in messages:
        for match in pattern.finditer(msg):
            rating_str = match.group(1)
            ratings.append(int(rating_str))

    return ratings


def main():
    print("🔍 Checking commit messages for CodeRating...")

    messages = get_commit_messages()
    if not messages:
        print("No commit messages found in PR range.")
        sys.exit(1)

    ratings = extract_ratings(messages)

    if not ratings:
        print("❌ No 'CodeRating: X/5' found in any commit message.")
        print("   Please add a line like 'CodeRating: 4/5' to at least one commit in this PR.")
        sys.exit(1)

    max_rating = max(ratings)
    print(f"Found ratings: {ratings}")
    print(f"Highest rating in PR: {max_rating}/5")

    required = 4
    if max_rating < required:
        print(f"❌ Highest rating {max_rating}/5 is below required {required}/5. Failing check.")
        sys.exit(1)

    print(f"✅ Rating requirement satisfied (≥ {required}/5).")
    sys.exit(0)


if __name__ == "__main__":
    main()
