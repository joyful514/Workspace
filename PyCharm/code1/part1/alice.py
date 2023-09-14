filename = "text_files/alice.txt"
try:
    with open(filename) as file:
        contents = file.read()
except FileNotFoundError:
        print("File not found")
else:
    words=contents.split()
    num_character=len(contents)
    num_words=len(words)
    print(f"The file {filename} contents is"
          f" :{words},num_words is {num_words}")
