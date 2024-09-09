function piccolo(inputArr) {
    let parkingLot = [];

    inputArr.forEach(entry => {
        const [command, number] = entry.split(', ');

        if (command == 'IN' && !parkingLot.includes(number)) {
            parkingLot.push(number);
        }

        if (command == 'OUT' && parkingLot.includes(number)) {
            parkingLot = parkingLot?.filter(item => item != number);
        }
    });

    if (parkingLot.length == 0) {
        console.log('Parking Lot is Empty');
    } else {
        console.log(parkingLot.sort((a, b) => a.localeCompare(b)).join('\n'));
    }
}

piccolo([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU',
]);
