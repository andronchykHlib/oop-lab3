START_NUMBER=10
END_NUMBER=29
DIRECTORY="files"

for i in $(seq $START_NUMBER $END_NUMBER); do
  if [ ! -d "$DIRECTORY" ]; then
    mkdir "$DIRECTORY"
  fi
  printf '%s\n' "$i" "$(($i + 1))" > "$DIRECTORY/$i.txt"
done