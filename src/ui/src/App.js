import './App.css';
import { BrowserRouter as Router, Route, Routes, } from 'react-router-dom';
import Layout from './components/Layout/Layout';
import Header from './components/Header/Header';
import Menu from './components/Menu/Menu';
import Footer from './components/Footer/Footer';
import Searchbar from './components/UI/Searchbar/Searchbar';
import { Suspense, useEffect, useReducer, useState } from 'react';
import ErrorBoundary from './hoc/ErrorBoundary';
import { initialState, reducer } from './reducer';
import AuthContext from './context/AuthContext';
import NotFound from './pages/404/NotFound';
import Login from './pages/Auth/Login/Login';
import Register from './pages/Auth/Register/Register';
import Item from './pages/Item/Item';
import Home from './pages/Home/Home';
import ReducerContext from './context/ReducerContext';
import Notification from './components/Notification/Notification';
import NotificationContext from './context/NotificationContext';
import AddItem from './pages/Items/AddItem/AddItem';
import Items from './pages/Items/Items';
import RequireAuth from './hoc/RequireAuth';
import EditItem from './pages/Items/EditItem/EditItem';
import DeleteItem from './pages/Items/DeleteItem/DeleteItem';
import PutItemForSale from './pages/Items/PutItemForSale/PutItemForSale';
import Search from './pages/Search/Search';
import Profile from './pages/Profile/Profile';
import ProfileDetails from './pages/Profile/ProfileDetails/ProfileDetails';
import ContactData from './pages/Profile/ContactData/ContactData';
import Cart from './pages/Cart/Cart';
import Currencies from './pages/Currencies/Currencies';
import EditCurrency from './pages/Currencies/EditCurrency/EditCurrency';
import AddCurrency from './pages/Currencies/AddCurrency/AddCurrency';
import CartSummary from './pages/Cart/Finalize/CartSummary';
import OrderItemArchive from './pages/Archive/OrderItemArchive';
import AddOrder from './pages/Order/AddOrder/AddOrder';
import EditContact from './pages/Profile/ContactData/EditContact/EditContact';
import AddOrderContact from './pages/Order/Contact/AddOrderContact';
import EditOrderContact from './pages/Order/Contact/EditOrderContact';
import AddContact from './pages/Profile/ContactData/AddContact/AddContact';

function App() {
  const [state, dispatch] = useReducer(reducer, initialState);
  const [notifications, setNotifications] = useState([]);
  
  const addNotification = (notification) => {
    const newNotification = [...notifications, notification]
    setNotifications(newNotification);
  };
  const deleteNotification = (id) => {
    setNotifications(notifications.filter(n => n.id !== id));
  };

  const header = (
    <Header >
      <Searchbar />
    </Header>
  );

  const menu = (
    <Menu />
  )

  const content = (
    <Suspense fallback={<p>Ładowanie...</p>} >
      <Routes>
        <Route path='/orders/add' element = { <RequireAuth> <AddOrder /> </RequireAuth> } >
          <Route path='add-contact' element = {<AddOrderContact />} />
          <Route path='edit-contact/:id' element = {<EditOrderContact />} />
        </Route>
        <Route path='/archive/items/:id' element = { <RequireAuth> <OrderItemArchive /> </RequireAuth>} />
        <Route path='/items/for-sale' element = { <RequireAuth> <PutItemForSale /> </RequireAuth>} />
        <Route path='/items/delete' element = { <RequireAuth> <DeleteItem /> </RequireAuth>} />
        <Route path='/items/edit' element = { <RequireAuth> <EditItem /> </RequireAuth>} />
        <Route path='/items/add' element = { <RequireAuth> <AddItem /> </RequireAuth>} />
        <Route path='/items/:id' element = {  <Item />} />
        <Route path='/search' element = {<Search />} >  
          <Route path=":term" element = {<Search />} />
          <Route path="" element = {<Search />} />
        </Route>
        <Route path="profile" element = {
                                          <RequireAuth>
                                            <Profile/>
                                          </RequireAuth>
                                        }  >
                          
          <Route path="contact-data" element = {<ContactData />} >
            <Route path="add" element = {<AddContact />} />
            <Route path="edit/:id" element = {<EditContact />} />
          </Route>
          <Route path="" element = {<ProfileDetails/>} />
        </Route>
        <Route path='/cart/summary' element = { <RequireAuth> <CartSummary/> </RequireAuth> } />
        <Route path='/currencies' element = { <RequireAuth> <Currencies /> </RequireAuth>} >
          <Route path='edit/:id' element = { <RequireAuth> <EditCurrency /> </RequireAuth> } />
          <Route path='add' element = { <RequireAuth> <AddCurrency /> </RequireAuth> } />
        </Route>
        <Route path='/items' element = { <RequireAuth> <Items /> </RequireAuth>} />
        <Route path='/cart' element = { <Cart /> } />
        <Route path='/login' element = {<Login />} />
        <Route path='/register' element = {<Register />} />
        <Route path="/" end element = {<Home />} />
        <Route path="*" element = {<NotFound/>} />
      </Routes>
    </Suspense>
  )

  const footer = (
    <Footer />
  )

  return (
    <Router>
      <AuthContext.Provider value = {{
          user: state.user,
          login: (user) => dispatch({ type: "login", user }),
          logout: () => dispatch({ type: "logout" })
      }}>
        <ReducerContext.Provider value={{
          state: state,
          dispatch: dispatch
        }} >
          <NotificationContext.Provider value={{
            notifications: notifications,
            addNotification: addNotification,
            deleteNotification: deleteNotification
          }}>
            <ErrorBoundary>
              <Layout 
                header = {header}
                menu = {menu}
                content = {content}
                footer = {footer}
                />

              {notifications.map(({ id, color, text, timeToClose }) => (
                    <Notification key={id} id={id} color={color} text={text} timeToClose={timeToClose} />
              ))}
            </ErrorBoundary>
          </NotificationContext.Provider>
        </ReducerContext.Provider>
      </AuthContext.Provider>
    </Router>
  );
}

export default App;
