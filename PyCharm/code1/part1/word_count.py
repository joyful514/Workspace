def count_word(filename):
    """计算一个文件大致包含多少个单词。"""
    try:
        with open(filename, 'r', encoding='utf-8') as f:
            contents = f.read()
    except FileNotFoundError:
        print(f"Sorry,the file {filename} does not exists.")
    else:
        words = contents.split()
        num_words = len(words)
        print(f"The file {filename} has about {num_words} words.")


filename = 'text_files/alice.txt'
count_word(filename)
