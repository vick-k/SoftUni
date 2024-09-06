function phoneBook(arr) {
    let phoneBook = {};

    for (const entry of arr) {
        let data = entry.split(' ');
        let name = data[0];
        let phoneNumber = data[1];

        phoneBook[name] = phoneNumber;
    }

    for (const key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`);
    }
}

phoneBook(['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344']);
