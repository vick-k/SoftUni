function repeatString(text, count) {
    let result = '';

    for (let i = 0; i < count; i++) {
        result += text;
    }

    return result;
}

repeatString('abc', 3);
