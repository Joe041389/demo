let Div = document.getElementById('app');
let Username = 'Jay';

const ObjUser = {
    //firstname: 'Jay',
    //lastname:'Wu'
};

const ObjUser2 = {
    firstname: 'Nana',
    lastname: 'Do'
};

function FunUser(ObjUser) {
    if (ObjUser) {
        return ObjUser.firstname + ObjUser.lastname;
    }
    else {
        return ObjUser2.firstname + ObjUser2.lastname;
    };
    
};

const Job = 'Student';
const Age = 18;
const ImgUrl = 'https://img.laughingbombclub.com/upload/842/719/35bfc1fe8960e1.jpg';
//const DT = new Date().toLocaleTimeString();


function tick() {
    const Element = (
        <h1>Hello {FunUser(ObjUser)}
            <ul>
                <li>Job : {Job}</li>
                <li>Age : {Age}</li>
                <li>Now : {new Date().toLocaleTimeString()}</li>
            </ul>
            Img: <img src={ImgUrl} width="200" height="250" />
        </h1>
    );

    ReactDOM.render(
        Element,
        Div
    );
}

setInterval(tick, 1000);

//const Element = (
//    <h1>Hello {FunUser(ObjUser)}
//        <ul>
//            <li>Job : {Job}</li>
//            <li>Age : {Age}</li>
//            <li>Now : {DT}</li>
//        </ul>
//        Img: <img src={ImgUrl} width="200" height="250"/>
//    </h1>
//);

//ReactDOM.render(
//    Element,
//    Div
//);


