import './App.css'
import Grid from '@mui/material/Grid'
import Form from './Form'
import Box from '@mui/material/Box'
import Typography  from '@mui/material/Typography'
import { getForecast } from './services'
import { useMemo, useState } from 'react'
import { Forecast } from './types'
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from 'chart.js';
import { Line } from 'react-chartjs-2';
import styled from '@mui/material/styles/styled'

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);



function App() {
  const [forecast,setForecast]=useState<{data:Forecast,label:string}[]>([])
  const [loading,setLoading]=useState(false)
  const onSearch=async(address:string)=>{
    try {
      setLoading(true)
      const response = await getForecast(address)
      setForecast(response.map((item)=>({data:item,label:item.name})))
    } catch (error) {
      console.log(error)
    }finally{
setLoading(false)
    }
  }
  
  const labels = useMemo(() => forecast.map(item=>item.label), [forecast]);
  const options = {
    plugins: {
      legend: {
        position: 'top' as const,
      },
      title: {
        display: true,
        text: 'ForeCast Line Chart',
      },
    },
  };
  const data = useMemo(()=>({
  labels,
  datasets:[{
    label:'Temperature',
    data:forecast.map(item=>item.data.temperature),
    borderColor: 'rgb(255, 99, 132)',  
  },
  ]
  }),[forecast, labels])


  return (
    <Grid width='100%'>
      <Typography variant='h4' component='h4' mb={4}>Weather Forecast</Typography>
      <Form onSearch={onSearch} loading={loading}/>
      {forecast.length===0 && <Typography variant='h5'  width='100%' my={4}>No forecast available or type a valid address</Typography>}
      {forecast.length>0&&
      <Grid display='flex'flexDirection='column' alignItems='center' mt={3}>
<Typography variant='h5'  width='100%' my={4}>Forecast for the next 7 days</Typography>
      <Container >
       <Line options={options} data={data} />;
       </Container>
      </Grid>}

    </Grid>
  )
}


const Container = styled(Box)(({ theme }) => ({
  [theme.breakpoints.down(600)]: {
    width:'600px'
  },
  [theme.breakpoints.up(900)]: {
    width:'900px'
  },
}))

export default App
