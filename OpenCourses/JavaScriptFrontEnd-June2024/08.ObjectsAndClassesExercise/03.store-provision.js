function storeProvision(firstArr, secondArr) {
    let stockProducts = [];
    let orderedProducts = [];

    for (let i = 0; i < firstArr.length - 1; i += 2) {
        const newProduct = {
            name: firstArr[i],
            quantity: Number(firstArr[i + 1]),
        };

        stockProducts.push(newProduct);
    }

    for (let i = 0; i < secondArr.length - 1; i += 2) {
        const newProduct = {
            name: secondArr[i],
            quantity: Number(secondArr[i + 1]),
        };

        orderedProducts.push(newProduct);
    }

    let updatedProducts = stockProducts.slice();

    orderedProducts.forEach(product => {
        if (!updatedProducts.find(pr => pr.name == product.name)) {
            updatedProducts.push(product);
        } else {
            const currentProduct = updatedProducts.find(pr => pr.name == product.name);
            currentProduct.quantity += product.quantity;
        }
    });

    updatedProducts.forEach(product => console.log(`${product.name} -> ${product.quantity}`));
}

storeProvision(
    ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']
);
