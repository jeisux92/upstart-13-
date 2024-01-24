import  Grid  from '@mui/material/Grid';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import React from 'react';

interface FormProps{
    onSearch:(address:string)=>void;
    loading:boolean;
}

const Form = ({onSearch,loading}:FormProps) => {
    const [search, setSearch] = React.useState('4600 Silver Hill Rd,  Washington, DC 20233');
    const handleChange=(e:React.ChangeEvent<HTMLInputElement>)=>{
        setSearch(e.target.value);
    }
    const onClick=()=>{        
        onSearch(search);
        setSearch('');
    }
    return (<Grid display='flex'>
        <TextField type="text" placeholder='Type address'size='small' onChange={handleChange} value={search}/>
        <Button variant='contained' onClick={onClick} disabled={loading}>Search</Button>
        </Grid>
    );
};

export default Form;
