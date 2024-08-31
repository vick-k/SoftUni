function censoredWords(text, word) {
    let symbol = '*';
    let censored;

    censored = text.replaceAll(word, symbol.repeat(word.length));
    console.log(censored);
}

censoredWords('A small sentence with some words', 'small');