const userForm = document.getElementById('userForm');
const userDataElement = document.getElementById('userData');

userForm.addEventListener('submit', async function (e) {
    e.preventDefault();

   

    try {
        const response = await fetch('https://localhost:7292/WeatherForecast/Merhaba');

        const userData = await response.json();
       const  dataArray = Object.values(userData)
        console.log(dataArray[3].name);
        userData.forEach(user => {
            const li= document.createElement('li')
            li.innerHTML = `
                                            <p>Kullanıcı Adı: ${user.name}</p>
                    <p>E-posta: ${user.description}</p>
                `;
            userDataElement.appendChild(li)
        })
        
    } catch (error) {
        console.error('Kullanıcı oluşturulurken bir hata oluştu:', error);
    }
});