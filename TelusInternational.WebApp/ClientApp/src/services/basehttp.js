export async function post(route, body) {
  try {
    const response = await fetch(route, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        // usually token bearer is here for API auth, I haven't implemented it for this test project
      },
      body: JSON.stringify(body),
    });
    if (response.status === 200) {
      return response.json();
    }
  } catch (err) {
    console.error(`GET error: ${err}`);
  }
}
