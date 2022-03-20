import styles from './Items.module.css'
import Item from './Item/Item'
import { createGuid } from '../../helpers/createGuid';

function Items(props) {
    const id = createGuid();
    const cost = 1500;
    const item = {
        id: id,
        name: "Iphone 13s Pro",
        cost: cost,
        imageUrl: `https://placeimg.com/220/18${Math.floor(Math.random() * 10)}/arch`
    }

    console.log(props);

    return (
        <div>
            <h1 className={styles.title}>Oferty:</h1>
            <div className='row me-2'>
                {props.items.map(i => 
                            <Item name={i.item.itemName}
                                  cost={i.cost}
                                  imageUrl={i.item.imageUrl.url} />
                )}

                <Item {...item} />
                <Item {...item} />
                <Item {...item} />
                <Item {...item} />
                <Item {...item} />
                <Item {...item} />
            </div>
            
        </div>
    );
}

export default Items;