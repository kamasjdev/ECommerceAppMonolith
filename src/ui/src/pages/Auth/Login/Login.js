import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import LoadingButton from "../../../components/UI/LoadingButton/LoadingButton";
import useAuth from "../../../hooks/useAuth";
import axios from '../../../axios-setup';

function Login() {
    const [auth, setAuth] = useAuth();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false);
    const [valid, setValid] = useState(null);
    const [error, setError] = useState('');

    const submit = async (event) => {
        event.preventDefault();
        setLoading(true);
        
        try {
            const response = await axios.post('users-module/account/sign-in', {
                email,
                password
            });
            setAuth({
                email: response.data.email,
                token: response.data.accessToken,
                userId: response.data.id
            })
            navigate('/');
        } catch (exception) {
            console.log(exception.response.data);
            setLoading(false);
        }
    }

    useEffect(() => {
        if (auth) {
            navigate('/');
        }
    }, [auth]);

    return (
        <div>
            <h2>Logowanie</h2>

            {valid === false ? (
                <div className="alert alert-danger">
                    Niepoprawne dane logowania
                </div>
            ) : null}

            <form onSubmit={submit}>
                <div className="form-group">
                    <label htmlFor="email-input" >Email</label>
                    <input name="email" 
                        id="email-input"
                        value={email} 
                        onChange={event => setEmail(event.target.value)} 
                        type="email" 
                        className="form-control" />
                </div>
                <div className="form-group">
                    <label>Hasło</label>
                    <input name="password" 
                        value={password} 
                        onChange={event => setPassword(event.target.value)} 
                        type="password" 
                        className="form-control" />
                </div>

                {error ? (
                    <div className="alert alert-danger">
                        {error}
                    </div>
                ) : null}

                <LoadingButton loading={loading} >Zaloguj</LoadingButton>
            </form>
        </div>
    )
}

export default Login;