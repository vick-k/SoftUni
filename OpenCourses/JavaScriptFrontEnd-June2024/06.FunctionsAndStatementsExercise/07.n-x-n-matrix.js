function printMatrix(number) {
    for (let i = 0; i < number; i++) {
        console.log(`${number} `.repeat(number).trimEnd());
    }
}

printMatrix(5);
