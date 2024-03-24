<script lang="ts">
    import LoadingSpinner from "$bcl/LoadingSpinner.svelte";
</script>

<div class="overlay">
    <LoadingSpinner iconSize={5}></LoadingSpinner>
</div>

<style lang="css">
    .overlay {
        background-color: #00000088;
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        display: flex;
        align-items: center;
        justify-content: center;

        & .icon {
            height: 10rem;
            width: 10rem;
        }
    }
</style>