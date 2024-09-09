function oddOccurrences(input) {
    const words = input.toLowerCase().split(' ');

    let oddOccurrencesWords = [];

    words.forEach(word => {
        let count = 0;

        for (let i = 0; i < words.length; i++) {
            if (word == words[i]) {
                count++;
            }
        }

        if (count % 2 != 0 && !oddOccurrencesWords.find(w => w == word)) {
            oddOccurrencesWords.push(word);
        }
    });

    console.log(oddOccurrencesWords.join(' '));
}

oddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
