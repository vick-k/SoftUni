function printAndSum(startNumber, endNumber) {
    let numbers = '';
    let sum = 0;

    for (let i = startNumber; i <= endNumber; i++) {
        numbers += `${i} `;
        sum += i;
    }

    console.log(numbers.trimEnd());
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10);