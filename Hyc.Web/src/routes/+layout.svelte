<script lang="ts">
    import TopNavHeader from "../components/headers/TopNavHeader.svelte";
</script>

<style lang="css" src="./layout.css">
</style>

<svelte:head>
</svelte:head>

<div class="app">
    <header>
        <TopNavHeader />
    </header>
    <main class="main container">
        <slot></slot>
    </main>

    <footer></footer>
</div>