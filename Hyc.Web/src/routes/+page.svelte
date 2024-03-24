<script lang="ts">
    // import Header from '../../../Hyc.MsPoc/src/routes/Header.svelte';
    import AppSelectBoard from "$components/boards/AppSelectBoard.svelte";
    import Canvas from "../components/canvases/Canvas.svelte";
</script>

<style lang="css">
    @import './global-styles.css';

    .page {
        height: var(--base-canvas-height);
    }
</style>

<div class="page">
    <AppSelectBoard/>
</div>