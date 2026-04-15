import { useState } from 'react'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

    const updateCount = () => {
      setCount(count + 1);
    }

  return (
    <>
      <h1>HELLO</h1>
      <p>{count}</p>
      <button onClick={updateCount}>Update count</button>
    </>
  )
}

export default App
