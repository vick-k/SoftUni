function stringSubstring(word, text) {
    const lowerCaseText = text.toLowerCase();
    const lowerCaseWord = word.toLowerCase();
    const words = lowerCaseText.split(' ');

    for (const word of words) {
        if (word == lowerCaseWord) {
            console.log(word);
            return;
        }
    }

    console.log(`${word} not found!`);
}

stringSubstring('javascript', 'JavaScript is the best programming language');
stringSubstring('python', 'JavaScript is the best programming language');
