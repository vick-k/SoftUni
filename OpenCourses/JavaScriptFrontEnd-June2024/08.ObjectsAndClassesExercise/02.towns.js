function towns(inputArr) {
    let allCities = [];

    inputArr.forEach(city => {
        const [town, latitude, longitude] = city.split(' | ');

        const newCity = {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        };

        allCities.push(newCity);
    });

    allCities.forEach(city => console.log(city));
}

towns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
