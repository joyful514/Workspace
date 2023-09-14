def get_formatted_name(first,last,middle=None):
    if middle==None:
        full_name=f"{first.title()} {last.title()}"
    else:
        full_name=f"{first.title()} {middle.title()} {last.title()}"
    return full_name