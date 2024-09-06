function addressBook(arr) {
    let addressBook = {};

    for (const entry of arr) {
        let data = entry.split(':');
        let name = data[0];
        let address = data[1];

        addressBook[name] = address;
    }

    let entries = Object.entries(addressBook);
    entries.sort((a, b) => a[0].localeCompare(b[0]));

    for (const entry of entries) {
        console.log(`${entry[0]} -> ${entry[1]}`);
    }
}

addressBook(['Tim:Doe Crossing',
    'Bill:Nelson Place',
    'Peter:Carlyle Ave',
    'Bill:Ornery Rd']);
