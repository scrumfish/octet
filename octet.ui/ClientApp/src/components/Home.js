import React, { useState } from 'react'
import { Button, Form } from 'reactstrap'

const Home = () => {
  const [resp, setResp] = useState()
  const encoder = new TextEncoder()
  const utf = encoder.encode("Encoded test")

  const onSubmit = async (e) => {
    e.preventDefault()
    const response = await fetch('/api/octet', {
      method: 'PUT',
      headers: {
        'Content-Type': 'octet-stream'
      },
      body: utf
    })
    if (response.ok){
      const text = await response.text()
      setResp(text)
    }
  }

  return (
    <div>
      <h1>Post This</h1>
      <Form onSubmit={onSubmit}>
        <Button type='submit'>Post</Button>
      </Form>
      {!!resp &&
        <div>
          <p>{resp}</p>
        </div>
      }
    </div>
  );
}

export default Home
