function reverseNumbers(number, array) {
    let newArray = [];
    
    for (let i = 0; i < number; i++) {
        newArray.push(array[i]);
    }
    
    let output = newArray.reverse().join(' ');
    console.log(output);
}

reverseNumbers(3, [10, 20, 30, 40, 50]);