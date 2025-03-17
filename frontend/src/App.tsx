import './App.css'

function Welcome() {
  return <h1>Hello?</h1>
}

function Footer() {
  return (
  <footer>
    <p>I need a bigger gun</p>
  </footer>
  );
}

function Content() {
  return (
    <>
      <p>Is this thing on?</p>
      <p>Am I all alone?</p>
    </>
  );
}

function App() {

  return (
    <>
      <Welcome />
      <Content />
      <Footer />
    </>
  )
}

export default App
