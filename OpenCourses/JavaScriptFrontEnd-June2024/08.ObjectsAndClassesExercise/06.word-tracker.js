function wordTracker(wordsArr) {
    const specialWords = wordsArr[0].split(' ');

    let output = [];

    specialWords.forEach(word => {
        let specialWord = {
            name: word,
            count: 0,
        };

        for (let i = 1; i < wordsArr.length; i++) {
            if (wordsArr[i] == word) {
                specialWord.count++;
            }
        }

        output.push(specialWord);
    });

    output
        .sort((a, b) => b.count - a.count)
        .forEach(word => console.log(`${word.name} - ${word.count}`));
}

wordTracker([
    'is the',
    'first',
    'sentence',
    'Here',
    'is',
    'another',
    'the',
    'And',
    'finally',
    'the',
    'the',
    'sentence',
]);
