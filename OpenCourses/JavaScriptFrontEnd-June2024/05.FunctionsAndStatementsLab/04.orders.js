function orders(product, quantity) {
    const coffeePrice = 1.50;
    const waterPrice = 1.00;
    const cokePrice = 1.40;
    const snacksPrice = 2.00;

    let totalPrice = 0;

    switch (product) {
        case 'coffee':
            totalPrice = coffeePrice * quantity;
            break;
        case 'water':
            totalPrice = waterPrice * quantity;
            break;
        case 'coke':
            totalPrice = cokePrice * quantity;
            break;
        case 'snacks':
            totalPrice = snacksPrice * quantity;
            break;
    }

    console.log(totalPrice.toFixed(2));
}

orders('water', 5);
