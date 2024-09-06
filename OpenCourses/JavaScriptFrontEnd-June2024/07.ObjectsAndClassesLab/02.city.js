function cityInfo(cityObj) {
    let keys = Object.keys(cityObj);

    for (const key of keys) {
        console.log(`${key} -> ${cityObj[key]}`);
    }
}

cityInfo({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
});
