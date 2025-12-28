<script lang="ts">
	import '../styles/global.css';

	let { children } = $props();
</script>

<svelte:head>
</svelte:head>

{@render children()}
