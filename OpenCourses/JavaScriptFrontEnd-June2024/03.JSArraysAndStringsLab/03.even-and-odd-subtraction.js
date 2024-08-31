function subtraction(array) {
    let evenSum = 0;
    let oddSum = 0;
    
    for (let i = 0; i < array.length; i++) {
        if (array[i] % 2 == 0) {
            evenSum += array[i];
        } else {
            oddSum += array[i];
        }
    }

    const result = evenSum - oddSum;
    console.log(result);
}

subtraction([1, 2, 3, 4, 5, 6]);