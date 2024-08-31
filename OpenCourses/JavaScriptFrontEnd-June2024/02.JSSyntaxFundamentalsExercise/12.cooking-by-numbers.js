function cookingByNumbers(number, operation1, operation2, operation3, operation4, operation5) {
    let currentNumber = Number(number);
    
    if (operation1 == 'chop') {
        currentNumber /= 2;
        console.log(currentNumber);
    } else if (operation1 == 'dice') {
        currentNumber = Math.sqrt(currentNumber);
        console.log(currentNumber);
    } else if (operation1 == 'spice') {
        currentNumber += 1;
        console.log(currentNumber);
    } else if (operation1 == 'bake') {
        currentNumber *= 3;
        console.log(currentNumber);
    } else if (operation1 == 'fillet') {
        currentNumber *= 0.8;
        console.log(currentNumber);
    }

    if (operation2 == 'chop') {
        currentNumber /= 2;
        console.log(currentNumber);
    } else if (operation2 == 'dice') {
        currentNumber = Math.sqrt(currentNumber);
        console.log(currentNumber);
    } else if (operation2 == 'spice') {
        currentNumber += 1;
        console.log(currentNumber);
    } else if (operation2 == 'bake') {
        currentNumber *= 3;
        console.log(currentNumber);
    } else if (operation2 == 'fillet') {
        currentNumber *= 0.8;
        console.log(currentNumber);
    }

    if (operation3 == 'chop') {
        currentNumber /= 2;
        console.log(currentNumber);
    } else if (operation3 == 'dice') {
        currentNumber = Math.sqrt(currentNumber);
        console.log(currentNumber);
    } else if (operation3 == 'spice') {
        currentNumber += 1;
        console.log(currentNumber);
    } else if (operation3 == 'bake') {
        currentNumber *= 3;
        console.log(currentNumber);
    } else if (operation3 == 'fillet') {
        currentNumber *= 0.8;
        console.log(currentNumber);
    }

    if (operation4 == 'chop') {
        currentNumber /= 2;
        console.log(currentNumber);
    } else if (operation4 == 'dice') {
        currentNumber = Math.sqrt(currentNumber);
        console.log(currentNumber);
    } else if (operation4 == 'spice') {
        currentNumber += 1;
        console.log(currentNumber);
    } else if (operation4 == 'bake') {
        currentNumber *= 3;
        console.log(currentNumber);
    } else if (operation4 == 'fillet') {
        currentNumber *= 0.8;
        console.log(currentNumber);
    }

    if (operation5 == 'chop') {
        currentNumber /= 2;
        console.log(currentNumber);
    } else if (operation5 == 'dice') {
        currentNumber = Math.sqrt(currentNumber);
        console.log(currentNumber);
    } else if (operation5 == 'spice') {
        currentNumber += 1;
        console.log(currentNumber);
    } else if (operation5 == 'bake') {
        currentNumber *= 3;
        console.log(currentNumber);
    } else if (operation5 == 'fillet') {
        currentNumber *= 0.8;
        console.log(currentNumber);
    }
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');