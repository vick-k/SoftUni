function charactersInRange(charOne, charTwo) {
    function getNumericValue(char) {
        return char.charCodeAt(0);
    }

    const numOne = getNumericValue(charOne);
    const numTwo = getNumericValue(charTwo);

    const range = Math.abs(numOne - numTwo) - 1;
    const smallerNumber = Math.min(numOne, numTwo);

    let outputChars = [];

    for (let i = 1; i <= range; i++) {
        let char = String.fromCharCode(smallerNumber + i);
        outputChars.push(char);
    }

    console.log(outputChars.join(' '));
}

charactersInRange('a', 'd');
