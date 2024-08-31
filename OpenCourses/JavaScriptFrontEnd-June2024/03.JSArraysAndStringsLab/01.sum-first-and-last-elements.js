function sumFirstAndLastElements(array) {
    const firstElement = array[0];
    const lastElement = array[array.length - 1];
    const sum = firstElement + lastElement;
    console.log(sum);
}

sumFirstAndLastElements([20, 30, 40]);