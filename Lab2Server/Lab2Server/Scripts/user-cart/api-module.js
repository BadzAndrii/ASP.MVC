var CartModule = (function (redraw) {
    var $session = sessionStorage,
        redraw = redraw && redraw.bind(this),
        $cartKey = "user@shopping-list.key",
        $noContentMsg = $("#no-content-msg"),
        data = $session.getItem($cartKey) || [];

    function save() { $session.setItem($cartKey, data); }

    function load() {
        data = $session.getItem($cartKey) || [];

        return new Promise(function (resolve, reject) {

            return $.ajax({
                cache: true,
                method: "GET",
                dataType: "json",
                url: "api/cart",
                data: { cartData: data.map(i => { return { Key: i.Id, Value: i.Count }; }) }
            })
            .done(result => resolve(result))
            .fail(reject);
        });
    }

    function insert(id) {
        return new Promise(function (resolve, reject) {
            try {
                data.find(e => e.Book.Id === id).Count++;
                resolve();
            } catch (msg) {
                data.push({ Count: 1, Book: { Id: id } });
                reject();
            }
        });
    }

    function update(id, conunt) {
        return new Promise(function (resolve, reject) {
            try {
                data.find(e => e.Book.Id === id).Count = count;
                resolve();
            } catch (msg) {
                reject();
            }
        }).then(save);
    }

    function remove(id) {
        return new Promise(function (resolve, reject) {
            try {
                data.splice(data.findIndex(e => e.Book.Id === id));
                resolve();
            } catch (msg) {
                reject();
            }
        }).then(save);
    }

    return {
        get: load,
        refresh: () => redraw,
        post: (id) => { return insert(id).then(redraw) },
        put: (id, conunt) => { return update(id, conunt).then(redraw) },
        delete: (id) => { return remove(id).then(redraw) },
    };
});