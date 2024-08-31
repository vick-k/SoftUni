function roadRadar(speed, area) {
    const motorwaySpeedLimit = 130;
    const interstateSpeedLimit = 90;
    const citySpeedLimit = 50;
    const residentialSpeedLimit = 20;

    const isMotorway = area == 'motorway';
    const isInterstate = area == 'interstate';
    const isCity = area == 'city';
    const isResidential = area == 'residential';

    let status = '';
    let speedLimit = 0;
    let overTheLimit = 0;
    let isWithinTheSpeedLimit = true;

    if (isMotorway && speed > motorwaySpeedLimit) {
        isWithinTheSpeedLimit = false;
        speedLimit = motorwaySpeedLimit;
        overTheLimit = speed - motorwaySpeedLimit;

        if (overTheLimit <= 20) {
            status = 'speeding';
        } else if (overTheLimit <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

    } else if (isInterstate && speed > interstateSpeedLimit) {
        isWithinTheSpeedLimit = false;
        speedLimit = interstateSpeedLimit;
        overTheLimit = speed - interstateSpeedLimit;

        if (overTheLimit <= 20) {
            status = 'speeding';
        } else if (overTheLimit <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

    } else if (isCity && speed > citySpeedLimit) {
        isWithinTheSpeedLimit = false;
        speedLimit = citySpeedLimit;
        overTheLimit = speed - citySpeedLimit;

        if (overTheLimit <= 20) {
            status = 'speeding';
        } else if (overTheLimit <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

    } else if (isResidential && speed > residentialSpeedLimit) {
        isWithinTheSpeedLimit = false;
        speedLimit = residentialSpeedLimit;
        overTheLimit = speed - residentialSpeedLimit;

        if (overTheLimit <= 20) {
            status = 'speeding';
        } else if (overTheLimit <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
    }

    if (isWithinTheSpeedLimit) {
        if (isMotorway) {
            console.log(`Driving ${speed} km/h in a ${motorwaySpeedLimit} zone`);
        } else if (isInterstate) {
            console.log(`Driving ${speed} km/h in a ${interstateSpeedLimit} zone`);
        } else if (isCity) {
            console.log(`Driving ${speed} km/h in a ${citySpeedLimit} zone`);
        } else if (isResidential) {
            console.log(`Driving ${speed} km/h in a ${residentialSpeedLimit} zone`);
        }
    } else {
        console.log(`The speed is ${overTheLimit} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

roadRadar(21, 'residential');