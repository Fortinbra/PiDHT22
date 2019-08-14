var sensor = require("node-dht-sensor");

function doSomething(arg) {
    sensor.read(22, 4, function (err, temperature, humidity) {
        if (!err) {
            console.log('temp: ' + temperature.toFixed(1) + 'C, ' +
                'humidity: ' + humidity.toFixed(1) + '%'
            );
        }
    });
}
setInterval(doSomething,2000);