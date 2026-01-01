<script lang="ts">
	let imageUrl: string;

	import { onMount } from 'svelte';

	async function fetchImage() {
		let url: string = 'http://localhost:5199/randomphoto';

		const res = await fetch(url);

		const data = await res.json();

		console.log(data);

		imageUrl = data.photoUrl;
	}

	onMount(() => {
		fetchImage();
	});
</script>

<div class="main-container">
	<h1>Random Image Generator</h1>
	<div class="image-container">
		<img alt="random photo from unsplash" src={imageUrl} />
	</div>
	<button id="generate-image" on:click={fetchImage} >Generate Image</button>
</div>

<style>
	.main-container {
		display: flex;
		width: 100%;
		height: 100%;
		align-items: center;
		/* justify-content: center; */
		flex-direction: column;
	}
	h1 {
		font-size: 2.2rem;
		color: #76d5e1;
	}
	.image-container {
		width: 80rem;
		height: 50rem;
		position: relative;
		overflow: hidden;
		box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
		border-radius: 12px;
		border: 3px solid white;
	}
	.image-container img {
		width: 100%;
		height: 100%;
		object-fit: cover;
	}
	#generate-image {
		cursor: pointer;
		border: 4px solid #76d5e1;
		color: white;
		background-color: #353535;
		padding: 2rem 4rem;
		margin-top: 2rem;
		border-radius: 8px;
		font-size: 1.25rem;
		box-shadow:
			rgba(0, 0, 0, 0.25) 0px 54px 55px,
			rgba(0, 0, 0, 0.12) 0px -12px 30px,
			rgba(0, 0, 0, 0.12) 0px 4px 6px,
			rgba(0, 0, 0, 0.17) 0px 12px 13px,
			rgba(0, 0, 0, 0.09) 0px -3px 5px;
		transition: 0.5s ease;
	}
	#generate-image:hover {
		background-color: #76d5e1;
		color: black;
		transition: 0.5s ease;
	}
	#generate-image:active {
		transform: scale(0.90);
		transition: 0.3s;
	}
</style>
