<script lang="ts">
	let imageUrl: string;

	import { onMount } from "svelte";

	async function fetchData() {
		let url: string = 'http://localhost:5199/randomphoto';

		const res = await fetch(url);

        const data = await res.json();

        console.log(data);

		imageUrl = data.photoUrl;
	}

    onMount(() => {
        fetchData();
    });
</script>

<div class="main-container">
	<h1>Random Image Generator</h1>
	<img src={imageUrl}>
</div>

<style>
	.main-container {
		display: flex;
		width: 100%;
		height: 100%;
		align-items: center;
		justify-content: center;
	}
	h1 {
		font-size: 2.2rem;
		color: white;
	}
</style>
