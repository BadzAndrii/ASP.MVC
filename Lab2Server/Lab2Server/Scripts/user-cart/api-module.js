var CartModule = (function (redrawCounter, redrawContent) {
    /* stub user functions */
    redrawCounter = redrawCounter || function () { console.warn("CartModule", "redrawCounter func is not set"); };
    redrawContent = redrawContent || function () { console.warn("CartModule", "redrawContent func is not set"); };

    /* private members */
    var $session = sessionStorage,
        $cartKey = "user@shopping-list.key",
        $noContentMsg = $("#no-content-msg"),
        data = JSON.parse($session.getItem($cartKey)) || [];

    function save() { $session.setItem($cartKey, JSON.stringify(data)); }

    function load() {
        data = JSON.parse($session.getItem($cartKey)) || [];

        return $.ajax({
            cache: true,
            method: "GET",
            dataType: "json",
            url: "api/cart",
            data: { cartData: { Items: data } }
        });
    }

    function insert(id) {
        return new Promise(function (resolve, reject) {
            if (data.find(e => e.Id === id))
                data.find(e => e.Id === id).Count++;
            else
                data.push({ Id: id, Count: 1 });
            resolve(data);
        })
        .then(save)
        .then(() => redrawCounter(data.length));
    }

    function update(id, count) {
        return new Promise(function (resolve, reject) {
            try {
                data.find(e => e.Id === id).Count = Number(count);
                resolve();
            } catch (msg) {
                reject();
            }
        })
        .then(save)
        .then(() => redrawCounter(data.length));
    }

    function remove(id) {
        return new Promise(function (resolve, reject) {
            try {
                data.splice(data.findIndex(e => e.Id === id), 1);
                resolve();
            } catch (msg) {
                reject();
            }
        })
        .then(save)
        .then(() => redrawCounter(data.length));
    }

    /* module */
    return {
        get: () => { return load().then(redrawContent) },
        post: insert,
        put: update,
        delete: remove,

        refresh: () => redrawCounter(data.length),
    };
});