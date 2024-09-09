function makeDictionary(inputArr) {
    let dictionary = {};

    for (const entry of inputArr) {
        const jsonObj = JSON.parse(entry);
        let keys = Object.keys(jsonObj);

        for (const key of keys) {
            dictionary[`${key}`] = `${jsonObj[key]}`;
        }
    }

    const entries = Object.entries(dictionary).sort((a, b) => a[0].localeCompare(b[0]));

    entries.forEach(entry => console.log(`Term: ${entry[0]} => Definition: ${entry[1]}`));
}

makeDictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}',
]);
