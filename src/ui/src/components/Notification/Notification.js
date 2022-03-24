import PropTypes from "prop-types";
import styles from "./Notification.module.css";
import { ReactComponent as Times } from "./times.svg";
import cn from "classnames";
import { useEffect, useRef } from "react";

let timeToClose = 3000;

function Notification(props) {
    const notify = useRef();

    const onDelete = (event) => {
        event.preventDefault();
        notify.current.remove();
    };

    useEffect(() => {
        const timeoutId = setTimeout(() => {
            notify.current.remove();
        }, props.timeToClose);
        
        return () => {
            clearTimeout(timeoutId);
        }
    }, []);

    return (
        <div ref={notify} className={styles.position}>
            <div className={cn([styles.notification, styles[props.color]])}>
                {props.text}
                <button onClick={onDelete} className={styles.closeButton}>
                    <Times height={16} />
                </button>
            </div>
        </div>
    );
};

export const Color = {
    info: "info",
    success: "success",
    warning: "warning",
    error: "error",
};

Notification.propTypes = {
    notificationType: PropTypes.oneOf(Object.keys(Color)),
    text: PropTypes.string,
    timeToClose: PropTypes.number
};

Notification.defaultProps = {
    color: Color.info,
    text: 'This is notification',
    timeToClose: timeToClose
}

export default Notification;