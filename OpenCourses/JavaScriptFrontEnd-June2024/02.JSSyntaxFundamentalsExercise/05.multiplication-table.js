function multiplicationTable(number) {
    for (let i = 1; i <= 10; i++) {
        const result = number * i;
        console.log(`${number} X ${i} = ${result}`);
    }
}

multiplicationTable(5);