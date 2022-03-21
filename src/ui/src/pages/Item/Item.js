import axios from "../../axios-setup";
import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import styles from './Item.module.css';
import Gallery from "../../components/Gallery/Gallery";
import { mapToItem } from "../../helpers/mapper";

function Item(props) {
    const { id } = useParams();
    const [item, setItem] = useState(null);

    const fetchItem = async () => {
        const response = await axios.get(`/items-module/item-sales/${id}`);
        setItem(mapToItem(response.data));
        console.log(response.data);
        console.log('item');
        console.log(mapToItem(response.data));
    }

    useEffect(() => {
        fetchItem();
    }, []);

    return (
        <>
            {item ? (
                <div className={`card ${styles.item}`}>
                    <div className="card-body">
                        <div className="row">
                            <div className="col-4">
                                <img src={item.imagesUrl.find(im => im.mainImage).url} alt=""
                                    className="img-fluid img-thumbnail"/>
                            </div>
                            <div className="col-8">
                                <div className="row">
                                    <div className="col">
                                        <p className={styles.title}>{item.name}</p>
                                        <p className={styles.typeDesc}>Typ:</p>
                                        <p className={styles.type}>{item.type}</p>
                                        <p className={styles.brandDesc}>Firma:</p>
                                        <p className={styles.brand}>{item.brand}</p>
                                    </div>
                                    <div>
                                        <div className={`${styles.costTheme} float-end`}>
                                            <p>Cena:</p>
                                            <p className={styles.cost}>{item.cost}</p>
                                        </div>
                                    </div>
                                    <div>
                                        <button className="btn btn-primary float-end">Dodaj do koszyka</button>
                                    </div>
                                </div>
                            </div>
                            <div className="col-12">
                                <h5>Opis:</h5>
                                <p className={styles.description}>{item.description}</p>
                            </div>
                            <div className={styles.galery}>
                                <p>Galeria:</p>
                                <Gallery items={item.imagesUrl.filter(im => !im.mainImage).map(im => im.url)} />
                            </div>
                        </div>
                    </div>
                </div>
                ): null
            }
        </>
    )
}

export default Item;