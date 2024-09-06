function meetings(arr) {
    let meetings = {};

    for (const entry of arr) {
        let data = entry.split(' ');
        let day = data[0];
        let name = data[1];

        if (meetings.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
            continue;
        }

        meetings[day] = name;
        console.log(`Scheduled for ${day}`);
    }

    for (const key in meetings) {
        console.log(`${key} -> ${meetings[key]}`);
    }
}

meetings(['Monday Peter',
    'Wednesday Bill',
    'Monday Tim',
    'Friday Tim']);
