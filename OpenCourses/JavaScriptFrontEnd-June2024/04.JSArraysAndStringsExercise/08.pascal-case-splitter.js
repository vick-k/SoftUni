function pascalCaseSplitter(text) {
    const regex = /[A-Z][a-z]*/gm;
    const words = text.match(regex);
    const output = words.join(', ');

    console.log(output);
}

pascalCaseSplitter('HoldTheDoor');
