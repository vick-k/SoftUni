function circleArea(input) {
    let type = typeof(input);
    let result;

    if (type === 'number') {
        result = Math.PI * (input ** 2);
        console.log(result.toFixed(2));
    } else {
        result = `We can not calculate the circle area, because we receive a ${type}.`
        console.log(result);
    }
}

circleArea(5);