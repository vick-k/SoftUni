function revealWords(words, text) {
    const wordsArr = words.split(', ');
    for (const word of wordsArr) {
        const specialSymbol = '*';
        const template = specialSymbol.repeat(word.length);

        if (text.includes(template)) {
            text = text.replace(template, word);
        }
    }

    console.log(text);
}

revealWords('great', 'softuni is ***** place for learning new programming languages');
