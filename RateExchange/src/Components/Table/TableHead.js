function TableHead(props) {

    return (
        props.columnNames !== undefined &&
        <thead className = "table-head">
            <tr>
            {
                props.columnNames.map((item, index) => {
                    return (
                        <th key = { index }>{ item }</th>
                    )
                })  
            }  
            </tr>
        </thead >    
    )
}

export default TableHead