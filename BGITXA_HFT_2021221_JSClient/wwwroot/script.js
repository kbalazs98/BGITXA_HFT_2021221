let televisions = [];
let connection = null;
let televisionidtoupdate = -1;
setupSignalR();
getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:9910/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TelevisionCreated", (user, message) => {
        getdata();
    });

    connection.on("TelevisionDeleted", (user, message) => {
        getdata();
    });

    connection.on("TelevisionUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => { await start(); });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
async function getdata() {
    await fetch('http://localhost:9910/Television')
        .then(x => x.json())
        .then(y => televisions = y)
        /*.then(z => console.log(televisions))*/
        .then(e => display());

}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    televisions.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.id + "</td><td>" + t.model + "</td><td>" + t.price + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + `<button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>";
    });
}

function create() {
    let model = document.getElementById('Model').value;
    let price = document.getElementById('Price').value;
    let brandid = document.getElementById('BrandID').value;
    let orderid = document.getElementById('OrderID').value;

    fetch('http://localhost:9910/Television', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { model: model, price: price, brandId: brandid, orderId: orderid }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}
function remove(id) {
    fetch('http://localhost:9910/Television/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function showupdate(id) {
    televisionidtoupdate = id;
    document.getElementById('edit').style.display = 'inline';
    document.getElementById('Modeltoupdate').value = televisions.find(t => t['id'] == id)['model'];
    document.getElementById('Pricetoupdate').value = televisions.find(t => t['id'] == id)['price'];
    document.getElementById('BrandIDtoupdate').value = televisions.find(t => t['id'] == id)['brandId'];
    document.getElementById('OrderIDtoupdate').value = televisions.find(t => t['id'] == id)['orderId'];
}
function update() {
    document.getElementById('edit').style.display = 'none';
    let model = document.getElementById('Modeltoupdate').value;
    let price = document.getElementById('Pricetoupdate').value;
    let brandid = document.getElementById('BrandIDtoupdate').value;
    let orderid = document.getElementById('OrderIDtoupdate').value;

    fetch('http://localhost:9910/Television', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { Id: televisionidtoupdate, model: model, price: price, brandId: brandid, orderId: orderid }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}