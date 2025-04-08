app.post('/register', async (req, res) => {
    const user = new User(req.body);
    await user.save();

    const cart = new Giohang();
    await cart.save();

    user.GiohangId = cart.Id;
    await user.save();

    res.send('Tài khoản và giỏ hàng đã được tạo!');
});

